
/*
* Method created by 
* https://github.com/yeyintkoko/encrypt-decrypt-c--nodejs
*/
module.exports = function()
{
    var crypto = require("crypto");

    this.encrypt = function(text, key) {
        var alg = 'des-ede-cbc';
        var key = new Buffer(key, 'utf-8');
        var iv = new Buffer('QUJDREVGR0g=', 'base64');    //This is from c# cipher iv
      
        var cipher = crypto.createCipheriv(alg, key, iv);
        var encoded = cipher.update(text, 'ascii', 'base64');
        encoded += cipher.final('base64');
      
        return encoded;
    }

    this.decrypt = function(encryptedText, key){
        // var alg = 'des-ede-cbc';
        // var key = new Buffer(key, 'utf-8');
        // var iv = new Buffer('0000000000000000', 'base64');    //This is from c# cipher iv
      
        // var encrypted = new Buffer(encryptedText, 'base64');
        // var decipher = crypto.createDecipheriv(alg, key, iv);
        // var decoded = decipher.update(encrypted, 'binary', 'ascii');
        // decoded += decipher.final('ascii');
      
        // return decoded;

        // var decipher = crypto.createDecipher('aes-128-ecb', key);
			
		// chunks = []
		// chunks.push( decipher.update( new Buffer(encryptedText, "base64").toString("binary")) );
		// chunks.push( decipher.final('binary') );
		// var txt = chunks.join("");
        // txt = new Buffer(txt, "binary").toString("utf-8");
        // return txt;

        // var encrypt = crypto.createCipheriv('des-ede3', key, "eb4a7e2b");
        //  var theCipher = encrypt.update(encryptedText, 'utf8', 'base64');
        //  theCipher += encrypt.final('base64');

        var decrypt = crypto.createDecipheriv('des-ede3', key, "");
        var s = decrypt.update(theCipher, 'base64', 'utf8');

        return s + decrypt.final('utf8');
    }

    return this;
}