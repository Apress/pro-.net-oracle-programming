using System;
using System.Data;
using System.Data.OracleClient;

namespace Parameters
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
      Console.WriteLine("Executing input parameter sample...");
      theClass.load_table(oraConn);

      Console.WriteLine("Executing ouput parameter sample...");
      theClass.retrieve_row(oraConn, 4);

      Console.WriteLine("Executing input/output parameter sample...");
      theClass.calculate_points(oraConn, 4);

      Console.WriteLine("Executing return value parameter sample...");
      theClass.get_team(oraConn, 4);

      oraConn.Close();

      oraConn.Dispose();
    }

    private void load_table(OracleConnection con)
    {
      insert_row(con, 1, "Arsenal", 38, 26, 12, 0, 73, 26);
      insert_row(con, 2, "Chelsea", 38, 24, 7, 7, 67, 30);
      insert_row(con, 3, "Manchester United", 38, 23, 6, 9, 64, 35);
      insert_row(con, 4, "Liverpool", 38, 16, 12, 10, 55, 37);
      insert_row(con, 5, "Newcastle United", 38, 13, 17, 8, 52, 40);
      insert_row(con, 6, "Aston Villa", 38, 15, 11, 12, 48, 44);
      insert_row(con, 7, "Charlton Athletic", 38, 14, 11, 13, 51, 51);
      insert_row(con, 8, "Bolton Wanderers", 38, 14, 11, 12, 48, 56);
      insert_row(con, 9, "Fulham", 38, 14, 10, 14, 52, 46);
      insert_row(con, 10, "Birmingham City", 38, 12, 14, 12, 43, 48);
      insert_row(con, 11, "Middlesbrough", 38, 13, 9, 16, 44, 52);
      insert_row(con, 12, "Southampton", 38, 12, 11, 15, 44, 45);
      insert_row(con, 13, "Portsmouth", 38, 12, 9, 17, 47, 54);
      insert_row(con, 14, "Tottenham Hotspur", 38, 13, 6, 19, 47, 57);
      insert_row(con, 15, "Blackburn Rovers", 38, 12, 8, 18, 51, 59);
      insert_row(con, 16, "Manchester City", 38, 9, 14, 15, 55, 54);
      insert_row(con, 17, "Everton", 38, 9, 12, 17, 45, 57);
      insert_row(con, 18, "Leicester City", 38, 6, 15, 17, 48, 65);
      insert_row(con, 19, "Leeds United", 38, 8, 9, 21, 40, 79);
      insert_row(con, 20, "Wolverhampton Wanderers", 38, 7, 12, 19, 38, 77);

      Console.WriteLine("Table successfully loaded.");
      Console.WriteLine();
    }

    private void insert_row(OracleConnection con,
      decimal position,
      string team,
      decimal played,
      decimal wins,
      decimal draws,
      decimal losses,
      decimal goals_for,
      decimal goals_against)
    {
      // create parameter objects for each parameter
      OracleParameter p_position = new OracleParameter();
      OracleParameter p_team = new OracleParameter();
      OracleParameter p_played = new OracleParameter();
      OracleParameter p_wins = new OracleParameter();
      OracleParameter p_draws = new OracleParameter();
      OracleParameter p_losses = new OracleParameter();
      OracleParameter p_goals_for = new OracleParameter();
      OracleParameter p_goals_against = new OracleParameter();

      // set non-default attribute values
      p_position.DbType = DbType.Decimal;
      p_played.DbType = DbType.Decimal;
      p_wins.DbType = DbType.Decimal;
      p_draws.DbType = DbType.Decimal;
      p_losses.DbType = DbType.Decimal;
      p_goals_for.DbType = DbType.Decimal;
      p_goals_against.DbType = DbType.Decimal;

      p_position.ParameterName = "p_position";
      p_team.ParameterName = "p_team";
      p_played.ParameterName = "p_played";
      p_wins.ParameterName = "p_wins";
      p_draws.ParameterName = "p_draws";
      p_losses.ParameterName = "p_losses";
      p_goals_for.ParameterName = "p_goals_for";
      p_goals_against.ParameterName = "p_goals_against";

      // assign values
      p_position.Value = position;
      p_team.Value = team;
      p_played.Value = played;
      p_wins.Value = wins;
      p_draws.Value = draws;
      p_losses.Value = losses;
      p_goals_for.Value = goals_for;
      p_goals_against.Value = goals_against;

      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_test.insert_row", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // add parameters to collection
      cmd.Parameters.Add(p_position);
      cmd.Parameters.Add(p_team);
      cmd.Parameters.Add(p_played);
      cmd.Parameters.Add(p_wins);
      cmd.Parameters.Add(p_draws);
      cmd.Parameters.Add(p_losses);
      cmd.Parameters.Add(p_goals_for);
      cmd.Parameters.Add(p_goals_against);

      // execute the command
      cmd.ExecuteNonQuery();
    }

    private void retrieve_row(OracleConnection con, decimal position)
    {
      // this retrieves a row and displays to the console
      // it uses the position column to determine which row
      // to retrieve and display

      // create parameter objects for each parameter
      OracleParameter p_position = new OracleParameter();
      OracleParameter p_team = new OracleParameter();
      OracleParameter p_played = new OracleParameter();
      OracleParameter p_wins = new OracleParameter();
      OracleParameter p_draws = new OracleParameter();
      OracleParameter p_losses = new OracleParameter();
      OracleParameter p_goals_for = new OracleParameter();
      OracleParameter p_goals_against = new OracleParameter();

      // set non-default attribute values
      p_position.DbType = DbType.Decimal;
      p_played.DbType = DbType.Decimal;
      p_wins.DbType = DbType.Decimal;
      p_draws.DbType = DbType.Decimal;
      p_losses.DbType = DbType.Decimal;
      p_goals_for.DbType = DbType.Decimal;
      p_goals_against.DbType = DbType.Decimal;

      p_position.ParameterName = "p_position";
      p_team.ParameterName = "p_team";
      p_played.ParameterName = "p_played";
      p_wins.ParameterName = "p_wins";
      p_draws.ParameterName = "p_draws";
      p_losses.ParameterName = "p_losses";
      p_goals_for.ParameterName = "p_goals_for";
      p_goals_against.ParameterName = "p_goals_against";

      p_team.Direction = ParameterDirection.Output;
      p_played.Direction = ParameterDirection.Output;
      p_wins.Direction = ParameterDirection.Output;
      p_draws.Direction = ParameterDirection.Output;
      p_losses.Direction = ParameterDirection.Output;
      p_goals_for.Direction = ParameterDirection.Output;
      p_goals_against.Direction = ParameterDirection.Output;

      p_team.Size = 32;

      // assign values for input parameter
      p_position.Value = position;

      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_test.retrieve_row", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // add parameters to collection
      cmd.Parameters.Add(p_position);
      cmd.Parameters.Add(p_team);
      cmd.Parameters.Add(p_played);
      cmd.Parameters.Add(p_wins);
      cmd.Parameters.Add(p_draws);
      cmd.Parameters.Add(p_losses);
      cmd.Parameters.Add(p_goals_for);
      cmd.Parameters.Add(p_goals_against);

      // execute the command
      cmd.ExecuteNonQuery();

      // output the row to the console window
      Console.WriteLine("     Position: " + position.ToString());
      Console.WriteLine("         Team: " + p_team.Value);
      Console.WriteLine("       Played: " + p_played.Value.ToString());
      Console.WriteLine("         Wins: " + p_wins.Value.ToString());
      Console.WriteLine("        Draws: " + p_draws.Value.ToString());
      Console.WriteLine("       Losses: " + p_losses.Value.ToString());
      Console.WriteLine("    Goals For: " + p_goals_for.Value.ToString());
      Console.WriteLine("Goals Against: " + p_goals_against.Value.ToString());
      Console.WriteLine();
    }

    private void calculate_points(OracleConnection con, decimal inout)
    {
      // this gets the total points for a team in position inout
      // and returns the value using the inout parameter
  
      // create parameter object and set attributes
      OracleParameter p_inout = new OracleParameter();
      p_inout.DbType = DbType.Decimal;
      p_inout.Direction = ParameterDirection.InputOutput;
      p_inout.Value = inout;
      p_inout.ParameterName = "p_inout";

      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_test.calculate_points", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // add parameter to the collection
      cmd.Parameters.Add(p_inout);

      // execute the command
      cmd.ExecuteNonQuery();

      // output the result to the console window
      Console.WriteLine("Total Points for position {0}: {1}",
        inout.ToString(), p_inout.Value.ToString());

      Console.WriteLine();
    }

    private void get_team(OracleConnection con, decimal position)
    {
      // gets the name of the team in position

      // create parameter objects and set attributes
      OracleParameter p_position = new OracleParameter();
      p_position.DbType = DbType.Decimal;
      p_position.Value = position;
      p_position.ParameterName = "p_position";

      OracleParameter p_retval = new OracleParameter();
      p_retval.Direction = ParameterDirection.ReturnValue;
      p_retval.Size = 32;
      p_retval.ParameterName = "p_retval";

      // create the command object and set attributes
      OracleCommand cmd = new OracleCommand("league_test.get_team", con);
      cmd.CommandType = CommandType.StoredProcedure;

      // add parameters to the collection
      cmd.Parameters.Add(p_retval);
      cmd.Parameters.Add(p_position);

      // execute the command
      cmd.ExecuteNonQuery();

      // output the result to the console window
      Console.WriteLine("Team in position {0}: {1}",
        position.ToString(), p_retval.Value.ToString());
    }
  }
}
