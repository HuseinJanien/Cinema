create trigger delTic
on Session
instead of delete
as
begin
declare @Id int
select @Id = Id from deleted
delete from Tickets where SessionId=@Id
delete from Session  where Id=@Id
end