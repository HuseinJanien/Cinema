create trigger DelAge
on AgeRestriction
instead of delete
as
begin
declare @Age int, @AgeRestrictionId int
select @Age=Age from deleted
select @AgeRestrictionId=Id from AgeRestriction where Age=@Age
delete from Films  where AgeId=@AgeRestrictionId
delete from AgeRestriction where @Age=Age
end