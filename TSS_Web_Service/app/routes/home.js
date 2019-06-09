var dbConnection = require('../../config/conn')

module.exports = function(app)
{
    app.get('/', function(req, res){
        var connection  = dbConnection();
        res.render("home/index");
    });
}