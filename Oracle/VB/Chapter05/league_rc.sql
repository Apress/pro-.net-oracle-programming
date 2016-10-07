create or replace package league_rc as
  type ref_cursor is ref cursor return league_results%rowtype;

  function get_table return ref_cursor;
  procedure get_table (p_cursor out ref_cursor);
end league_rc;
/

create or replace package body league_rc as
  function get_table return ref_cursor is
    l_cursor ref_cursor;
  begin
    open l_cursor for
    select   position,
             team,
             played,
             wins,
             draws,
             losses,
             goals_for,
             goals_against
    from     league_results
    order by position;

    return l_cursor;
  end get_table;

  procedure get_table (p_cursor out ref_cursor) is
  begin
    open p_cursor for
    select   position,
             team,
             played,
             wins,
             draws,
             losses,
             goals_for,
             goals_against
    from     league_results
    order by position;
  end get_table;
end league_rc;
/
