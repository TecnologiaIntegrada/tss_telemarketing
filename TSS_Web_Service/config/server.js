var express = require('express');
var consign = require('consign');
var bodyParser = require('body-parser');

var app = express();
app.set('view engine', 'ejs');
app.set('views', './app/views');

app.use(bodyParser.urlencoded({ extended: true }));

consign()
    .include('app/routes')
    .then('config/conn.js')
    .then('app/models')
    .then('app/modules')
    .into(app);

module.exports = app;