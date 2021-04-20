-- List all of the movies ordered alphabetically.

SELECT * FROM movies
ORDER BY title

----------------------------------------------------------------------

-- List the three oldest people from oldest to youngest.

SELECT TOP 3 * FROM people
ORDER BY birthdate

----------------------------------------------------------------------

-- List all of the people who have directed a movie.

SELECT DISTINCT p.* FROM people p
JOIN mtm_credits c ON
p.id = c.person_id
JOIN roles r ON
r.id = c.role_id
WHERE r.role = 'Director'

----------------------------------------------------------------------

-- Which director has directed the most movies in our database?

SELECT TOP 1
p.name,
COUNT(c.movie_id) 'Movies Directed'
FROM people p
JOIN mtm_credits c ON
p.id = c.person_id
JOIN roles r ON
r.id = c.role_id
WHERE r.role = 'Director'
GROUP BY p.name
ORDER BY 'Movies Directed' DESC

----------------------------------------------------------------------

-- Which people are both directors and actors?

SELECT p.* FROM people p
WHERE p.id IN
(
	-- Select all actors
	SELECT DISTINCT p.id FROM people p
	JOIN mtm_credits c ON
	p.id = c.person_id
	JOIN roles r ON
	r.id = c.role_id
	WHERE
	r.role = 'Actor'
)
AND p.id IN
(
	-- Select all directors
	SELECT DISTINCT p.id FROM people p
	JOIN mtm_credits c ON
	p.id = c.person_id
	JOIN roles r ON
	r.id = c.role_id
	WHERE
	r.role = 'Director'
)

----------------------------------------------------------------------

-- List all of the people who have worked with Ben Affleck.

SELECT DISTINCT p.* FROM people p
JOIN mtm_credits c
ON p.id = c.person_id
JOIN movies m
ON m.id = c.movie_id
WHERE m.id IN
(
  -- All movies that have Ben Affleck
  SELECT m.id FROM movies m
  JOIN mtm_credits c ON
  m.id = c.movie_id
  JOIN people p ON
  p.id = c.person_id
  WHERE
  p.name = 'Ben Affleck'
)
AND p.NAME <> 'Ben Affleck' -- Ignore Ben Affleck working with himself