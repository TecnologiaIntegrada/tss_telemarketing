module.exports = function(application)
{
    application.post('/api/v1/sql/run', function(req, res){
        var postdata = req.body;

        var connection = application.config.conn();
        var sqlModel = application.app.models.sqlModel;

        sqlModel.runQuery(postdata, connection,  function(error, result){
            var data = { 'error': error, 'result': result};
            res.send(data);
        });
    });

    application.get('/api/v1/sql/run', function(req, res){
       res.send("{'error': 'can not access this route'}");
    });
}