var crypto = require('crypto');

var alg = 'des-ede-cbc';

var key = new Buffer('abcdefghijklmnop', 'utf-8');
var iv = new Buffer('pdMBMjdeFdo=', 'base64');

console.log('key as binary: ', iv);
console.log('key as string:', Buffer.from(iv, 'binary').toString('base64'));

var encrypted = new Buffer('czY2Uv08kF8=', 'base64');

var source = 'TEST';

var cipher = crypto.createCipheriv(alg, key, iv);
var encoded = cipher.update(source, 'ascii', 'base64');
encoded += cipher.final('base64');

console.log(encoded, encrypted.toString('base64'));

var decipher = crypto.createDecipheriv(alg, key, iv);
var decoded = decipher.update(encrypted, 'binary', 'ascii');
decoded += decipher.final('ascii');

console.log(decoded, source);