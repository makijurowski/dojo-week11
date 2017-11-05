CREATE VIEW likes_users AS
SELECT likes.LikeId AS LikeId,
likes.UserId AS UserId,
aspnetusers.Alias AS Alias,
aspnetusers.FName AS Fname,
likes.PostId AS PostId 
FROM likes 
JOIN aspnetusers 
ON (likes.UserId = aspnetusers.UserId);