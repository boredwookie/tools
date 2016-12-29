var fs = require('fs');
var sql = require('sql.js');

var db = null;

function openNotedDatabase(path_to_db){
  var exists = fs.existsSync(path_to_db);
  if(!exists){
    return "failed_to_open_db";
  }
  dbf = fs.readFileSync(path_to_db);
  db = sql.Database(dbf);

  return db;
}
