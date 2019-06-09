var mysql = require("mysql");

var connMySql = function()
{
    return mysql.createConnection({
        host: '127.0.0.1',
        user: 'root',
        password: '',
        database: 'tss_telemarketing'
    });
}

module.exports = function()
{
    return connMySql;
}