var app = require('./config/server')

var homeRoute = require('./app/routes/home');
homeRoute(app);

app.listen(3000, function(){
    console.log("Server ON");
});

