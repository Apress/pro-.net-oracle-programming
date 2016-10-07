using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Associative
{
  /// <summary>
  /// Summary description for Class1.
  /// </summary>
  class Class1
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      // for using our helpers
      Class1 theClass = new Class1();

      // create our standard connection
      string connStr = "User Id=oranetuser; Password=demo; Data Source=oranet";
      OracleConnection oraConn = new OracleConnection(connStr);

      oraConn.Open();

      // call the helper methods
      Console.WriteLine("Truncating table...");
      theClass.truncate_table(oraConn);
      Console.WriteLine("Completed truncating table...");
      Console.WriteLine();

      Console.WriteLine("Executing associative insert...");
      theClass.associative_insert(oraConn);
      Console.WriteLine("Completed associative insert...");
      Console.WriteLine();

      Console.WriteLine("Executing associative select...");
      theClass.associative_select(oraConn);
      Console.WriteLine("Completed associative select...");

      oraConn.Close();

      oraConn.Dispose();
    }

    private void truncate_table(OracleConnection con)
    {
      // a very simple helper method to truncate the
      // league_results table
      // since we will be inserting data that would
      // violate the primary key otherwise

      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("truncate table league_results", con);

      cmd.ExecuteNonQuery();
    }

    private void associative_insert(OracleConnection con)
    {
      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_associative.bulk_insert", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // create parameter objects for each parameter
      OracleParameter p_position = new OracleParameter();
      OracleParameter p_team = new OracleParameter();
      OracleParameter p_played = new OracleParameter();
      OracleParameter p_wins = new OracleParameter();
      OracleParameter p_draws = new OracleParameter();
      OracleParameter p_losses = new OracleParameter();
      OracleParameter p_goals_for = new OracleParameter();
      OracleParameter p_goals_against = new OracleParameter();

      // set parameter type for each parameter
      p_position.OracleDbType = OracleDbType.Decimal;
      p_team.OracleDbType = OracleDbType.Varchar2;
      p_played.OracleDbType = OracleDbType.Decimal;
      p_wins.OracleDbType = OracleDbType.Decimal;
      p_draws.OracleDbType = OracleDbType.Decimal;
      p_losses.OracleDbType = OracleDbType.Decimal;
      p_goals_for.OracleDbType = OracleDbType.Decimal;
      p_goals_against.OracleDbType = OracleDbType.Decimal;

      // set the collection type for each parameter
      p_position.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_team.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_played.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_wins.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_draws.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_losses.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_goals_for.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_goals_against.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

      // set the parameter values
      p_position.Value = new decimal[20]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                                          11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

      p_team.Value = new string[20]{"Arsenal", "Chelsea", "Manchester United",
                                     "Liverpool", "Newcastle United", "Aston Villa",
                                     "Charlton Athletic", "Bolton Wanderers", "Fulham",
                                     "Birmingham City", "Middlesbrough", "Southampton",
                                     "Portsmouth", "Tottenham Hotspur", 
                                     "Blackburn Rovers", "Manchester City", "Everton",
                                     "Leicester City", "Leeds United",
                                     "Wolverhampton Wanderers"};

      p_played.Value = new decimal[20]{38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 
                                        38, 38, 38, 38, 38, 38, 38, 38, 38, 38};

      p_wins.Value = new decimal[20]{26, 24, 23, 16, 13, 15, 14, 14, 14, 12, 13,
                                      12, 12, 13, 12, 9, 9, 6, 8, 7};

      p_draws.Value = new decimal[20]{12, 7, 6, 12, 17, 11, 11, 11, 10, 14, 9,
                                       11, 9, 6, 8, 14, 12, 15, 9, 12};

      p_losses.Value = new decimal[20]{0, 7, 9, 10, 8, 12, 13, 12, 14, 12,
                                        16, 15, 17, 19, 18, 15, 17, 17, 21, 19};

      p_goals_for.Value = new decimal[20]{73, 67, 64, 55, 52, 48, 51, 48, 52, 43,
                                           44, 44, 47, 47, 51, 55, 45, 48, 40, 38};

      p_goals_against.Value = new decimal[20]{26, 30, 35, 37, 40, 44, 51, 56, 46, 48,
                                               52, 45, 54, 57, 59, 54, 57, 65, 79, 77};

      // set the size for each array
      p_position.Size = 20;
      p_team.Size = 20;
      p_played.Size = 20;
      p_wins.Size = 20;
      p_draws.Size = 20;
      p_losses.Size = 20;
      p_goals_for.Size = 20;
      p_goals_against.Size = 20;

      // set array bind size for the team column since it
      // is a variable size type (varchar2)
      p_team.ArrayBindSize = new int[20]{32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
                                          32, 32, 32, 32, 32, 32, 32, 32, 32, 32};

      // add the parameters to the command object
      cmd.Parameters.Add(p_position);
      cmd.Parameters.Add(p_team);
      cmd.Parameters.Add(p_played);
      cmd.Parameters.Add(p_wins);
      cmd.Parameters.Add(p_draws);
      cmd.Parameters.Add(p_losses);
      cmd.Parameters.Add(p_goals_for);
      cmd.Parameters.Add(p_goals_against);

      // execute the insert
      cmd.ExecuteNonQuery();
    }

    private void associative_select(OracleConnection con)
    {
      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_associative.bulk_select", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // create parameter objects for each parameter
      OracleParameter p_position = new OracleParameter();
      OracleParameter p_team = new OracleParameter();
      OracleParameter p_played = new OracleParameter();
      OracleParameter p_wins = new OracleParameter();
      OracleParameter p_draws = new OracleParameter();
      OracleParameter p_losses = new OracleParameter();
      OracleParameter p_goals_for = new OracleParameter();
      OracleParameter p_goals_against = new OracleParameter();

      // set parameter type for each parameter
      p_position.OracleDbType = OracleDbType.Decimal;
      p_team.OracleDbType = OracleDbType.Varchar2;
      p_played.OracleDbType = OracleDbType.Decimal;
      p_wins.OracleDbType = OracleDbType.Decimal;
      p_draws.OracleDbType = OracleDbType.Decimal;
      p_losses.OracleDbType = OracleDbType.Decimal;
      p_goals_for.OracleDbType = OracleDbType.Decimal;
      p_goals_against.OracleDbType = OracleDbType.Decimal;

      // set the collection type for each parameter
      p_position.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_team.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_played.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_wins.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_draws.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_losses.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_goals_for.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
      p_goals_against.CollectionType = OracleCollectionType.PLSQLAssociativeArray;

      // set the direct for each parameter
      p_position.Direction = ParameterDirection.Output;
      p_team.Direction = ParameterDirection.Output;
      p_played.Direction = ParameterDirection.Output;
      p_wins.Direction = ParameterDirection.Output;
      p_draws.Direction = ParameterDirection.Output;
      p_losses.Direction = ParameterDirection.Output;
      p_goals_for.Direction = ParameterDirection.Output;
      p_goals_against.Direction = ParameterDirection.Output;

      // set the parameter values to null initially
      p_position.Value = null;
      p_team.Value = null;
      p_played.Value = null;
      p_wins.Value = null;
      p_draws.Value = null;
      p_losses.Value = null;
      p_goals_for.Value = null;
      p_goals_against.Value = null;

      // set the size for each array
      p_position.Size = 20;
      p_team.Size = 20;
      p_played.Size = 20;
      p_wins.Size = 20;
      p_draws.Size = 20;
      p_losses.Size = 20;
      p_goals_for.Size = 20;
      p_goals_against.Size = 20;

      // set array bind size for the team column since it
      // is a variable size type (varchar2)
      p_team.ArrayBindSize = new int[20]{32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
                                          32, 32, 32, 32, 32, 32, 32, 32, 32, 32};

      // add the parameters to the command object
      cmd.Parameters.Add(p_position);
      cmd.Parameters.Add(p_team);
      cmd.Parameters.Add(p_played);
      cmd.Parameters.Add(p_wins);
      cmd.Parameters.Add(p_draws);
      cmd.Parameters.Add(p_losses);
      cmd.Parameters.Add(p_goals_for);
      cmd.Parameters.Add(p_goals_against);

      // execute the insert
      cmd.ExecuteNonQuery();

      // display as comma separated list
      // field_count is used to determine when
      // we have completed a "line"
      int field_count = 1;
      for (int i = 0; i < p_position.Size; i++)
      {
        foreach (OracleParameter p in cmd.Parameters)
        {
          if (p.Value is OracleDecimal[])
          {
            Console.Write((p.Value as OracleDecimal[])[i]);
          }
          if (p.Value is OracleString[])
          {
            Console.Write((p.Value as OracleString[])[i]);
          }

          if (field_count < 8)
          {
            Console.Write(",");
          }
          else
          {
            field_count = 0;
          }

          field_count++;
        }
        Console.WriteLine();
      }
    }
  }
}
