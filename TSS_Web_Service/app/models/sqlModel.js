module.exports = function(application)
{
    this.runQuery = function(postdata, connection, callback)
    {
        var crypto = require('crypto');

        var alg = 'des-ede-cbc';

        var key = new Buffer('abcdefghijklmnop', 'utf-8');
        var iv = new Buffer('pdMBMjdeFdo=', 'base64');

        var encrypted = new Buffer(postdata.command, 'base64');
        //console.log(encrypted);

        var decipher = crypto.createDecipheriv(alg, key, iv);
        var decoded = decipher.update(encrypted, 'binary', 'ascii');
        decoded += decipher.final('ascii');

        //console.log(decoded);

        connection.query(decoded, callback);
    };
    return this;
}