# Highscore

## SQL

If you've made any changes to DbInitializer, e.g. added more games, scores etc. then you
might want to load these upon app startup. To do that, just remove all current games, users, 
and scores and then start the app.

```sql
USE Highscore

TRUNCATE TABLE Scores
TRUNCATE TABLE Games
TRUNCATE TABLE Users
```

