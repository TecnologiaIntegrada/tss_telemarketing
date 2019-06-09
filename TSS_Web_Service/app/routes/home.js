module.exports = function(application)
{
    application.get('/api/v1/users/list', function(req, res){
        var connection = application.config.conn();
        var usersModel = application.app.models.usersModel;

        usersModel.getUsers(connection,  function(error, result){
            res.send(result);
        });
    });

    application.post('/api/v1/users/save', function(req, res){
        var user = req.body;

        var connection = application.config.conn();
        var usersModel = application.app.models.usersModel;

        usersModel.saveUsers(user, connection,  function(error, result){
            var data = {created: true};
            res.send(data);
        });
    });

    application.post('/api/v1/users/login', function(req, res){
        var user = req.body;

        var connection = application.config.conn();
        var usersModel = application.app.models.usersModel;

        usersModel.loginUsers(user, connection,  function(error, result){
            var response = result.length > 0 ? result[0] : null;
            res.send(response);
        });
    });
}