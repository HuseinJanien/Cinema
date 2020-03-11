CREATE trigger delPlace
on Plases
instead of delete
as
begin
declare @Id int
select @Id = Id from deleted
delete from Tickets where PlaceId=@Id
delete from Plases where Id=@Id
end