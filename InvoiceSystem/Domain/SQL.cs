using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;

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
    public static class SQL
    {
        /// <summary>
        /// This SQL string gets all invoices from the database.
        /// </summary>
        /// <returns></returns>
        public static string GetAllInvoices()
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
                return "INSERT INTO Invoice(InvoiceDate, TotalCharge) VALUES(#" + invoice.InvoiceDate + "#," + invoice.TotalCharge + "," + ")";
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



        /// <summary>
        /// Returns a SQL statement to insert an Item into the ItemDesc Table.
        /// </summary>
        /// <param name="item">item to be inserted</param>
        /// <returns>string</returns>
        public static string insertItem(Item item)
        {
            try
            {
                return "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) Values ('" + item.ItemCode + "','" + item.ItemDesc + "','" + item.Cost + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to delete a Item in the ItemDesc table.
        /// </summary>
        /// <param name="sItemCode">invoice ID</param>
        /// <returns>string</returns>
        public static string deleteItem(string sItemCode)
        {
            try
            {
                return "DELETE FROM ItemDesc WHERE ItemCode = '" + sItemCode + "'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }


        /// <summary>
        /// Returns a SQL statement to update an Item given ItemCode.
        /// </summary>
        /// <param name="sOldItemCode">an Item's old code</param>
        /// <param name="sNewItemCode">an Item's new code</param>
        /// <param name="sNewItemDesc">an Item's new description</param>
        /// <param name="sNewItemCost">an Item's new cost</param>
        /// <returns>string</returns>
        public static string updateItem(string sOldItemCode, string sNewItemCode, string sNewItemDesc, string sNewItemCost)
        {
            try
            {
                return "UPDATE ItemDesc SET ItemCode = '" + sNewItemCode + "', ItemDesc = '" + sNewItemDesc + "', Cost = '" + sNewItemCost + "' WHERE ItemCode='" + sOldItemCode + "'";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " => " + ex.Message);
            }
        }

        /// <summary>
        /// Loads the invoices from the database and returns the data as a IList of Invoices
        /// </summary>
        /// <returns></returns>
        public static IList<Invoice> LoadInvoices()
        {
            var sql = @"
SELECT InvoiceNum, InvoiceDate, TotalCharge
FROM Invoices";

            var count = 0;
            var result = new Database().ExecuteSQLStatement(sql, ref count);
            var table = result.Tables[0];
            var columns = table.Columns;
            var invoiceNumColumn = columns["InvoiceNum"];
            var invoiceDateColumn = columns["InvoiceDate"];
            var totalChargeColumn = columns["TotalCharge"];

            var invoicesQuery =
               from DataRow row in result.Tables[0].Rows
               select new Invoice
               {
                   InvoiceNum = (int)row[invoiceNumColumn],
                   InvoiceDate = (DateTime)row[invoiceDateColumn],
                   TotalCharge = (decimal)row[totalChargeColumn]
               };

            return invoicesQuery.ToList();
        }
    }
}
