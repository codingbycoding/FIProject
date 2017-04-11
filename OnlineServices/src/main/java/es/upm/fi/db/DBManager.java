package es.upm.fi.db;

import es.upm.fi.utils.UTLogger;

import java.sql.Connection;
import java.sql.Statement;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Planned to use JDBC, but changed to Hibernate, this is deprecated.
 */
@Deprecated
public class DBManager {

    public static DBManager _instance = null;

    public DBManager() {
        if(null == _instance) {
            _instance = new DBManager();
        }
    }

    public void TestStatement() {
        Connection conn = null;
        Statement statement = null;
        try {
            conn =
                    DriverManager.getConnection("jdbc:mysql://localhost/PaseoUPM?" +
                            "user=qa&password=qa");

            statement = conn.createStatement();
            String sqlTest = new String("INSERT INTO user_accounts_tbl VALUES('avatar_id_10000000', 'FirstName', 'LastName', 'email@email.com', 20170122, 20170122, 1, 0, 'UserTitle')");
            statement.execute(sqlTest);

        } catch (SQLException ex) {

           UTLogger.error("SQLException: " + ex.getMessage());
            UTLogger.error("SQLState: " + ex.getSQLState());
            UTLogger.error("VendorError: " + ex.getErrorCode());
        } finally {
            try {

                if (statement != null) {
                    statement.close();
                }

                if (conn != null) {
                    conn.close();
                }

            } catch (SQLException ex) {

               UTLogger.error(ex.toString());
            }
        }
    }
}