create trigger DelCat
on Category
instead of delete
as
begin
declare @name nvarchar(max), @CategoryId int
select @name=Name from deleted
select @CategoryId=Id from Category where Name=@name
delete from Films  where CategoryId=@CategoryId
delete from Category where Name=@name
end