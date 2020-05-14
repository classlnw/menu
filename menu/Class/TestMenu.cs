using NoomLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace menu.Class
{
    public class TestMenu
    {
        //MainMenu
        private CStatement _Select_MainMenu;

        //Menu
        private CStatement _Select_Menu;

        //MainMenu
        public int MMCode { get; set; }
        public string MMName { get; set; }
        public int MMOrder { get; set; }

        //Menu
        public int MenuCode { get; set; }
        public int MenuName { get; set; }
        public int MenuOrder { get; set; }
        public int MenuImage { get; set; }
        public int MenuPath { get; set; }

        public TestMenu()
        {

            //MainMenu
            this._Select_MainMenu = new CStatement("Select_MainMenu", "Insert_Register", "updateTest", "deleteTest", CommandType.StoredProcedure);

            //Menu
            this._Select_Menu = new CStatement("Select_Menu", "Insert_Register", "updateTest", "deleteTest", CommandType.StoredProcedure);
        }

        public DataTable Select_MainMenu()
        {
            DataTable dt = new DataTable();
            CStatementList csta = new CStatementList(Connection.CSQLConnection);
            try //เช็ค Error ด้านในอีกที
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    //plist.Add("@typesearch", DbType.String, "Detail", ParameterDirection.Input);
                    CSQLStatementValue csv = new CSQLStatementValue(this._Select_MainMenu, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csv);
                    csta.Open();

                    //สั่งรัน เพื่อได้ข้อมูล Sql ออกมา dt = (Datatable)
                    dt = (DataTable)csta.Execute(adlist);

                }
                catch (SqlException)
                {
                    csta.Rollback();
                    throw;
                }
                finally
                {
                    csta.Close();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return dt;

        }

        //menu
        public DataTable Select_Menu(string MMName)
        {
            DataTable dt = new DataTable();
            CStatementList csta = new CStatementList(Connection.CSQLConnection);
            try //เช็ค Error ด้านในอีกที
            {
                try
                {
                    CSQLParameterList plist = new CSQLParameterList();
                    CSQLDataAdepterList adlist = new CSQLDataAdepterList();
                    plist.Add("@MMName", DbType.String, MMName, ParameterDirection.Input);
                    CSQLStatementValue csv = new CSQLStatementValue(this._Select_Menu, plist, NoomLibrary.StatementType.Select);
                    adlist.Add(csv);
                    csta.Open();

                    //สั่งรัน เพื่อได้ข้อมูล Sql ออกมา dt = (Datatable)
                    dt = (DataTable)csta.Execute(adlist);

                }
                catch (SqlException)
                {
                    csta.Rollback();
                    throw;
                }
                finally
                {
                    csta.Close();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return dt;

        }
    }
}