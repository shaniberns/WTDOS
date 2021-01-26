using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class DBHelper
    {

        //Constants
        public const int WRITEDATA_ERROR = -1;
        //class member variables
        private OleDbConnection conn; //holds the connection for all operations using OleDB
        private string provider; //holds the provider for the connection
        private string source; //holds the path to the database file
        private bool connOpen; //indicates if the connection is opened

        //Construct the object with a provided provider and source
        public DBHelper(string provider, string source)
        {
            this.provider = provider;
            this.source = source;
            this.conn = null;
            this.connOpen = false;
        }

        //Open connection to the database. return true if succeed. 
        //if not succeed return false
        public bool OpenConnection()
        {
            if (connOpen)
            {
                return true;
            }
            else
            {
                string connString = String.Format(@"Provider={0};Data Source={1};Persist Security Info=False;", this.provider, this.source);
                try
                {
                    OleDbConnection conn = new OleDbConnection(connString);
                    conn.Open();
                    this.conn = conn;
                    connOpen = true;
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    connOpen = false;
                    return false;
                }
            }
        }


        //Execute SELECT sql commands and return a reference to an OleDbDataReader
        //if execution fails return null
        public OleDbDataReader ReadData(string sql)
        {
            if (OpenConnection())
            {
                //Create Command and Reader for the data
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();

                //CHeck if reader was created
                if (rd != null)
                {
                    return rd;
                }
                else
                {
                    Console.WriteLine("Reader was not created!");
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //Execute UPDATE or INSERT sql commands and return number of rows affected.
        //return WRITEDATA_ERROR on failure.
        public int WriteData(string sql)
        {
            if (OpenConnection())
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                //CHeck if reader was created
                if (rd != null)
                {

                    return rd.RecordsAffected;
                }
                else
                {
                    return WRITEDATA_ERROR;
                }
            }
            else
            {
                return WRITEDATA_ERROR;
            }
        }

        //This function should be used for inserting a single record into a table in the database with an autonmuber key. 
        //the format of the sql must be          
        //INSERT INTO <TableName> (Fields...) VALUES (values...)         
        //the function return the autonumber key generated for the new record or WRITEDATA_ERROR if fail.   
        public int InsertWithAutoNumKey(string sql)
        {
            if (OpenConnection())
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader rd = cmd.ExecuteReader();

                //Check if insert was successful
                if (rd != null && rd.RecordsAffected == 1)
                {
                    //Create a new command for retrieving the new ID
                    //It MUST use the SAME connection!!!!
                    cmd = new OleDbCommand(@"SELECT @@Identity", conn);
                    rd = cmd.ExecuteReader();
                    int newID = -1;
                    while (rd.Read())
                    {
                        //The new ID will be on the first (and only) column
                        newID = (int)rd[0];
                    }
                    return newID;
                }
                else
                {
                    return WRITEDATA_ERROR;
                }
            }
            else
            {
                return WRITEDATA_ERROR;
            }
        }


        //This function is closing the connection unless it is already closed
        public void CloseConnection()
        {
            try
            {
                if (connOpen)
                {
                    conn.Close();
                    connOpen = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //This function builds the connection string to be used to open connection.
        private string BuildConnString()
        {
            return string.Format(@"Provider={0};Data Source={1};Persist Security Info=False;", this.provider, this.source);
        }



        //This function reads from the database a data table fully cached in memory using a standard SQL SELECT statement.
        //The function returns the data table or null on failure
        public DataTable GetDataTable(string sql)
        {
            try
            {
                string query = sql;
                DataTable dataTable = new DataTable();
                OleDbDataReader reader = ReadData(sql);
                if (reader == null)

                    return null;

                dataTable.Load(reader);
                return dataTable;

            }
            catch (OleDbException e)
            {
                return null;
            }

        }

        //This function reads from the database a data set fully cached in memory using an array of standard SQL SELECT statements.
        //The function returns the data set or null on failure. The table names inside the dataset are sql1, sql2,...
        public DataSet GetDataSet(string[] sql)
        {

            if (OpenConnection())
            {
                OleDbCommand cmd;
                DataSet ds = new DataSet();
                OleDbDataAdapter adapter;
                //Create Command and Reader for the data
                for (int i = 0; i < sql.Length; i++)
                {
                    cmd = new OleDbCommand(sql[i], conn);
                    adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(ds);
                }
                //Now we have the data in memory insode the dataTable and connection can be closed
                conn.Close();

                return ds;
            }
            else
            {
                return null;
            }
        }

    }
}
