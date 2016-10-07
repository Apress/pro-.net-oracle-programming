create or replace package league_associative as
  -- create a type for each column
  type t_position is table of league_results.position%type
    index by binary_integer;
  type t_team is table of league_results.team%type
    index by binary_integer;
  type t_played is table of league_results.played%type
    index by binary_integer;
  type t_wins is table of league_results.wins%type
    index by binary_integer;
  type t_draws is table of league_results.draws%type
    index by binary_integer;
  type t_losses is table of league_results.losses%type
    index by binary_integer;
  type t_goals_for is table of league_results.goals_for%type
    index by binary_integer;
  type t_goals_against is table of league_results.goals_against%type
    index by binary_integer;

  -- the procedures that will perform our work
  procedure bulk_insert (p_position in t_position,
                         p_team in t_team,
                         p_played in t_played,
                         p_wins in t_wins,
                         p_draws in t_draws,
                         p_losses in t_losses,
                         p_goals_for in t_goals_for,
                         p_goals_against in t_goals_against);

  procedure bulk_select (p_position out t_position,
                         p_team out t_team,
                         p_played out t_played,
                         p_wins out t_wins,
                         p_draws out t_draws,
                         p_losses out t_losses,
                         p_goals_for out t_goals_for,
                         p_goals_against out t_goals_against);
end league_associative;
/

create or replace package body league_associative as
  procedure bulk_insert (p_position in t_position,
                         p_team in t_team,
                         p_played in t_played,
                         p_wins in t_wins,
                         p_draws in t_draws,
                         p_losses in t_losses,
                         p_goals_for in t_goals_for,
                         p_goals_against in t_goals_against) is
  begin
    forall i in p_position.first..p_position.last
    insert into league_results (position,
                                team,
                                played,
                                wins,
                                draws,
                                losses,
                                goals_for,
                                goals_against)
                        values (p_position(i),
                                p_team(i),
                                p_played(i),
                                p_wins(i),
                                p_draws(i),
                                p_losses(i),
                                p_goals_for(i),
                                p_goals_against(i));
  end bulk_insert;

  procedure bulk_select (p_position out t_position,
                         p_team out t_team,
                         p_played out t_played,
                         p_wins out t_wins,
                         p_draws out t_draws,
                         p_losses out t_losses,
                         p_goals_for out t_goals_for,
                         p_goals_against out t_goals_against) is
  begin
    select   position,
             team,
             played,
             wins,
             draws,
             losses,
             goals_for,
             goals_against
    bulk collect into p_position,
                      p_team,
                      p_played,
                      p_wins,
                      p_draws,
                      p_losses,
                      p_goals_for,
                      p_goals_against
    from     league_results
    order by position;
  end bulk_select;
end league_associative;
/
