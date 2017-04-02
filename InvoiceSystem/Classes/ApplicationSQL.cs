using System;
using System.Reflection;

namespace InvoiceSystem
{
    /// <summary>
    /// Contains the SQL statements for managing the invoice data.
    /// 
    /// This part of the assignment is to create a class that contains the main pieces of SQL used throughout the project.  
    /// This class will be nothing but methods that contain different statements of SQL.  
    /// Make sure to create SQL statements that will help in meeting all requirements that use the database.  
    /// So SQL statements needed will be to select different types of data on each window, to update/insert/delete data on each form.  
    /// Use Microsoft Access to run the queries ahead of time to make sure the queries give you the expected data and work correctly.  
    /// Your SQL statements should be tested and working.  Below is an example of a class/method that should be used as a guide for your code.
    /// </summary>
    public class ApplicationSQL
    {
        /// <summary>
        /// This SQL string gets all invoices from the database.
        /// </summary>
        /// <returns></returns>
        public static string getAllInvoices()
        {
            try
            {
                return "SELECT * FROM Invoices";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement that gets all data on an invoice for a given InvoiceID.
        /// </summary>
        /// <param name="sInvoiceID">The InvoiceID for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public static string getInvoice(string sInvoiceID)
        {
            try
            {
                return "SELECT * FROM Invoices WHERE InvoiceID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to get an InvoiceID given invoice date and total charge.
        /// </summary>
        /// <param name="invoice">invoice object</param>
        /// <returns>string</returns>
        public static string getInvoiceID(Invoice invoice)
        {
            try
            {
                return "SELECT Invoice_ID FROM Invoice WHERE InvoiceDate = " + invoice.InvoiceDate + "AND TotalCharge = " + invoice.TotalCharge;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to insert an Invoice into the Invoice Table.
        /// </summary>
        /// <param name="invoice">invoice object to be inserted</param>
        /// <returns>string</returns>
        public static string insertInvoice(Invoice invoice)
        {
            try
            {
                // NOT COMPLETE Just a starting point
                return "INSERT INTO Invoice(InvoiceDate, TotalCharge, Items) VALUES(" + invoice.InvoiceDate + "," + invoice.TotalCharge + "," + invoice.InvoiceItems + ")";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to delete a Invoice in the Invoice table.
        /// </summary>
        /// <param name="sInvoiceID">invoice ID</param>
        /// <returns>string</returns>
        public static string deleteInvoice(string sInvoiceID)
        {
            try
            {
                return "DELETE FROM Invoice WHERE Invoice_ID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to update an Invoice given Invoice ID.
        /// </summary>
        /// <param name="sInvoiceID">invoice ID</param>
        /// /// <param name="updateVal">value to be updated</param>
        /// <returns>string</returns>
        public static string updateInvoice(string sInvoiceID, string updateVal)
        {
            try
            {
                // NOT COMPLETE just a starting point
                return "UPDATE Invoice SET something = " + updateVal + "WHERE Invoice_ID = " + sInvoiceID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }
    }
}
