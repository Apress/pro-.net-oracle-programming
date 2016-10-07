create or replace package league_test as
  procedure insert_row(p_position in number,
    p_team in varchar2,
    p_played in number,
    p_wins in number,
    p_draws in number,
    p_losses in number,
    p_goals_for in number,
    p_goals_against in number);

  procedure retrieve_row(p_position in number,
    p_team out varchar2,
    p_played out number,
    p_wins out number,
    p_draws out number,
    p_losses out number,
    p_goals_for out number,
    p_goals_against out number);

  procedure calculate_points(p_inout in out number);

  function get_team(p_position in number) return varchar2;
end league_test;
/

create or replace package body league_test as
  procedure insert_row(p_position in number,
    p_team in varchar2,
    p_played in number,
    p_wins in number,
    p_draws in number,
    p_losses in number,
    p_goals_for in number,
    p_goals_against in number) is
  begin
    -- insert a row into the table
    insert into league_results (position,
      team,
      played,
      wins,
      draws,
      losses,
      goals_for,
      goals_against)
    values (p_position,
      p_team,
      p_played,
      p_wins,
      p_draws,
      p_losses,
      p_goals_for,
      p_goals_against);
  end insert_row;

  procedure retrieve_row(p_position in number,
    p_team out varchar2,
    p_played out number,
    p_wins out number,
    p_draws out number,
    p_losses out number,
    p_goals_for out number,
    p_goals_against out number) is
  begin
    -- this returns the columns for a given position in the table
    select   team,
             played,
             wins,
             draws,
             losses,
             goals_for,
             goals_against
    into     p_team,
             p_played,
             p_wins,
             p_draws,
             p_losses,
             p_goals_for,
             p_goals_against
    from     league_results
    where    position = p_position;
  end retrieve_row;

  procedure calculate_points(p_inout in out number) is
  begin
    -- this returns the number of points for a given position
    -- in the table
    -- points are calculated as:
    --   3 points for a win
    --   1 point for a draw
    --   0 points for a loss
    select   (wins * 3) + (draws)
    into     p_inout
    from     league_results
    where    position = p_inout;
  end calculate_points;

  function get_team(p_position in number) return varchar2 is
    l_team league_results.team%type;
  begin
    -- simply get the team for a given position
    select   team
    into     l_team
    from     league_results
    where    position = p_position;

    return l_team;
  end get_team;
end league_test;
/
