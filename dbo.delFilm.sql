create trigger delFilm
on Films
instead of delete
as
begin
declare @Name nvarchar(max), @Filmid int
select @Name= Name from deleted
select @Filmid=Id from Films where Name=@Name
delete from Session where FilmId=@Filmid
delete from Films where Name=@Name
end