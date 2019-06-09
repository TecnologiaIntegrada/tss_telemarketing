module.exports = function()
{
    this.getUsers = function(connection, callback)
    {
        connection.query('SELECT * FROM users', callback);
    };

    this.saveUsers = function(user, connection, callback)
    {
        connection.query('INSERT INTO users SET ?', user, callback);
    };

    this.loginUsers = function(user, connection, callback)
    {
        var sql = "SELECT * FROM users u WHERE u.email='" + user.email + "' AND password='" + user.password + "'";
        connection.query(sql, callback);
    }

    return this;
}