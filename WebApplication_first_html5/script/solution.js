function solution1() {
    var cody = new Object();
    cody.living = true;
    cody.age = 33;
    cody.gender = "male";

    cody.getGender = function () {
        return cody.gender;
    };

    console.log("console log1 :" +
        " cody.living :" + cody.living +
        " cody.age :" +  cody.age +
        " cody.gender :" +  cody.gender +
        " cody.getGender() :" +  cody.getGender() +
        " cody :" +  cody);
}


function solution2() {

    var myNumber = new Number(23);
    //var myString = new String('male');
    var myBoolean = new Boolean(false);
    var myObject = new Object();
    var myArray = new Array("foo", "bar");
    var myFuntion = new function (x, y) { return (x * y); };

    var myDate = new Date();
    var myRegExp = new RegExp("\bt[a-z]+\b");
    //regexp veux dire expression reguliere
    var myErro = new Error("mais qu'est ce que sait!!!? my Error");



    console.log("console log2 :" +
        " myNumber :" + myNumber +
        //" myString :" + myString +
        " myBoolean :" + myBoolean +
        " myObject :" + myObject +
        " myArray :" + myArray +
        //" myFuntion :" + myFuntion(5, 6) +
        " myDate :" + myDate +
        " myRegExp :" + myRegExp +
        " myErro :" + myErro);
}

