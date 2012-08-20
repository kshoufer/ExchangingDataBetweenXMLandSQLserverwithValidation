using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Schema;

namespace XMLtoDatabaseWithValidation
{
    public partial class Form1 : Form
    {

        string strGenre;
        string strPubDate;
        System.DateTime datPubDate;
        string strISBN;
        string strTitle;
        string strAuthorFirstName;
        string strAuthorLastName;
        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();

        public Form1()
        {
            InitializeComponent();

        }

        private void btnWriteToXML_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=Bookstore;Integrated Security=True";


            //********************READ*********************************
            try
            {
                conn.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM Books;",
                    conn);

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        strGenre = (string)reader[1];
                        datPubDate = (System.DateTime)reader[2];
                        strPubDate = datPubDate.ToString();
                        strISBN = (string)reader[3];
                        strTitle = (string)reader[4];
                        strAuthorFirstName = (string)reader[5];
                        strAuthorLastName = (string)reader[6];

                        // Open an XML document.
                        System.Xml.XmlDocument myXmlDocument = new System.Xml.XmlDocument();
                        myXmlDocument.Load(@"C:\Users\ken\Documents\Visual Studio 2010\Projects\XMLtoSQLserver\XMLtoSQLserver\books1.xml");
                        System.Xml.XmlNode myXmlNodeFirstBook = myXmlDocument.DocumentElement.FirstChild;

                        // Create a Book element and populate its attributes
                        System.Xml.XmlElement XmlElementMyBook = myXmlDocument.CreateElement("book");
                        XmlElementMyBook.SetAttribute("genre", strGenre);
                        XmlElementMyBook.SetAttribute("publicationdate", strPubDate);
                        XmlElementMyBook.SetAttribute("ISBN", strISBN);
                        // Insert the new element into the XML tree under Catalog
                        myXmlDocument.DocumentElement.InsertBefore(XmlElementMyBook, myXmlNodeFirstBook);

                        // Create a new child of the book element
                        System.Xml.XmlElement myXmlElement2 = myXmlDocument.CreateElement("title");
                        myXmlElement2.InnerText = strTitle;
                        // Insert the new element under the node we created
                        XmlElementMyBook.AppendChild(myXmlElement2);

                        // Create a new child of the book element
                        System.Xml.XmlElement myXmlElement3 = myXmlDocument.CreateElement("author");
                        XmlElementMyBook.AppendChild(myXmlElement3);

                        // Create new child of the author element
                        System.Xml.XmlElement myXmlElement4 = myXmlDocument.CreateElement("first-name");
                        myXmlElement4.InnerText = strAuthorFirstName;
                        myXmlElement3.AppendChild(myXmlElement4);

                        // Create new child of the author element
                        System.Xml.XmlElement myXmlElement5 = myXmlDocument.CreateElement("last-name");
                        myXmlElement5.InnerText = strAuthorLastName;
                        myXmlElement3.AppendChild(myXmlElement5);

                        myXmlDocument.Save(@"C:\Users\ken\Documents\Visual Studio 2010\Projects\XMLtoSQLserver\XMLtoSQLserver\books1.xml");

                    }// end while
                }
                else
                {
                    Console.WriteLine("No rows found");
                }// end if (reader.HasRows)

                reader.Close();

            }// end try

            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to Books Table");
            }
            finally
            {
                conn.Close();
            }


            //********************END READ******************************

            lblDataWrittenToXML.Visible = true;

        }// end btnWriteToXML_Click

        private void btnWriteXMLtoDatabase_Click(object sender, EventArgs e)
        {

            //*******************test schema******************
            try
            {
                XmlDocument xmld = new XmlDocument();
                xmld.Load(@"C:\Users\ken\Documents\Visual Studio 2010\Projects\XMLtoDatabaseWithValidation\XMLtoDatabaseWithValidation\books.xml");
                xmld.Schemas.Add(null, @"C:\Users\ken\Documents\Visual Studio 2010\Projects\XMLtoDatabaseWithValidation\XMLtoDatabaseWithValidation\books.xsd");
                xmld.Validate(ValidationCallBack);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught a problem: " + ex.Message);
            }
            //******************end test schema***************
            
            
            // Create an XmlReader
            //using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            using (XmlReader reader = XmlReader.Create(@"C:\Users\ken\Documents\Visual Studio 2010\Projects\XMLtoSQLserver\XMLtoSQLserver\books.xml"))
            {
                
                
                
                reader.ReadToFollowing("book");
                reader.MoveToFirstAttribute();
                strGenre = reader.Value;
                reader.MoveToNextAttribute();
                strPubDate = reader.Value;
                datPubDate = DateTime.Parse(strPubDate); //convert to date format
                reader.MoveToNextAttribute();
                strISBN = reader.Value;
                reader.ReadToFollowing("title");
                strTitle = reader.ReadInnerXml();
                reader.ReadToFollowing("first-name");
                strAuthorFirstName = reader.ReadInnerXml();
                reader.ReadToFollowing("last-name");
                strAuthorLastName = reader.ReadInnerXml();


            }

            //Output to database
            try
            {
                conn.ConnectionString = @"Data Source=KEN-HP\SQLSERVER2008R2;Initial Catalog=Bookstore;Integrated Security=True";
                conn.Open();

                string queryStmt = "INSERT INTO Books(Genre, PublicationDate, ISBN, Title, AuthorFirstName, AuthorLastName)" +
                                    "VALUES(@Genre, @PublicationDate, @ISBN, @Title, @AuthorFirstName, @AuthorLastName)";

                using (SqlCommand _cmd = new SqlCommand(queryStmt, conn))
                {
                    _cmd.Parameters.Add("@Genre", SqlDbType.NVarChar, 50);
                    _cmd.Parameters.Add("@PublicationDate", SqlDbType.DateTime, 50);
                    _cmd.Parameters.Add("@ISBN", SqlDbType.NVarChar, 50);
                    _cmd.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
                    _cmd.Parameters.Add("@AuthorFirstName", SqlDbType.NVarChar, 50);
                    _cmd.Parameters.Add("@AuthorLastName", SqlDbType.NVarChar, 50);
                    _cmd.Parameters["@Genre"].Value = strGenre;
                    _cmd.Parameters["@PublicationDate"].Value = datPubDate;
                    _cmd.Parameters["@ISBN"].Value = strISBN;
                    _cmd.Parameters["@Title"].Value = strTitle;
                    _cmd.Parameters["@AuthorFirstName"].Value = strAuthorFirstName;
                    _cmd.Parameters["@AuthorLastName"].Value = strAuthorLastName;

                    _cmd.ExecuteNonQuery();
                }

            }// end try

            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert to Books Table");
            }
            finally
            {
                conn.Close();
            }

            lblXMLtoDatabase.Visible = true;

        }// end btnWriteXMLtoDatabase_Click

        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("There is a problem with the schema or xml document: " + "\n" + e.Message);
            
            throw new Exception();
        }


    }// end partial class Form1 : Form
}// end namespace XMLtoSQLserver
