﻿CREATE PROCEDURE GetAwardByID @ID int
AS
SELECT * FROM Awards WHERE ID = @ID