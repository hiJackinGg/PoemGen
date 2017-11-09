USE [PoemDB]
GO

--Dictionary data
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('black', 'x,-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('white', 'x,-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('dark', 'x,-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('light', 'x,-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('modern', 'x,-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('muddy', 'x-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('murky', 'x-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('modern', 'x-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('derived', '-x', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('amazing', '-x-', 'Adjective');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('wonderful', 'x--', 'Adjective');
 
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('heart', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('sun', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('moon', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('thunder', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('fire', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('time', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('wind', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('sea', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('river', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('flavor', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('wave', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('rain', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('tree', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('rain', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('flower', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('pasture', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('field', 'x,-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('meadow', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('pasture', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('harvest', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('water', 'x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('balloon', '-x', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('adventure', '-x-', 'Noun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('history', 'x--', 'Noun');

  INSERT INTO Dictionary(word, syllables, type)
  VALUES('my', 'x,-', 'Pronoun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('your', 'x,-', 'Pronoun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('his', 'x,-', 'Pronoun');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('her', 'x,-', 'Pronoun');


  INSERT INTO Dictionary(word, syllables, type)
  VALUES('runs', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('walks', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('stands', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('climbs', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('crawls', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('flows', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('flies', 'x,-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('transcends', 'x-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('ascends', 'x-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('descends', 'x-', 'Verb');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('sinks', 'x,-', 'Verb');

  INSERT INTO Dictionary(word, syllables, type)
  VALUES('once', 'x,-', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('from', 'x,-', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('then', 'x,-', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('above', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('across', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('against', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('along', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('around', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('beneath', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('beyond', '-x', 'Preposition');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('underneath', '--x', 'Preposition');

  INSERT INTO Dictionary(word, syllables, type)
  VALUES('and', 'x,-', 'Conjunction');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('or', 'x,-', 'Conjunction');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('also', 'x-', 'Conjunction');
  INSERT INTO Dictionary(word, syllables, type)
  VALUES('but', 'x,-', 'Conjunction');

--Schema data
  INSERT INTO [Schema](value)
  VALUES('x-x-x-x-x-\n-x-x-x-\n--x--x--x--x\nx--x--x-x--x');
  INSERT INTO [Schema](value)
  VALUES('-x-x-x-x-\n--x--x--x--x');
  INSERT INTO [Schema](value)
  VALUES('-x-x-x-x-x\n-x-x-x-\n--x--x--x--x\nx--x--x-x--x');
  INSERT INTO [Schema](value)
  VALUES('x-x-x-x-x\nx-x-x-x-x');





