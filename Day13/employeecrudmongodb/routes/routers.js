var express=require("express");
const { modelNames } = require("mongoose");
var mongoose=require("mongoose");
var schema=mongoose.Schema;
var router=express.Router();

//design model using mongoose schema
var empschema=new schema({
    _id:Number,
    empid:String,
    ename:{type:String,trim:true,required:true},
    sal:String
//sal:{type:Number,validate:/[0-9]*/}
})

//retireve data from emptab collection and 
//its schema is defined using empschema
//model(name,scema object, collection name)
//collection name is optional if model name and collection name is same
var Emp=mongoose.model('emptab',empschema,'emptab')


//to retrieve all records from mongodb and display 
//it in browser in table format
router.get("/",function(req,resp){
     Emp.find().exec(function(err,data){
         if(err){
            console.log(err);
             resp.status(500).send("no data found");
         }
         else{
             console.log(data);
             // render function will search index.jade in views folder
             resp.render("index",{title:"Employee Data",empdata:data})
         }

     });

});

/// to accept data in the form and add it in the databse

router.get("/create",function(req,resp){

    resp.render('create',{title:'Add Employee'});
})

//this add new document in the collection
router.post("/adddata",function(req,resp){
    var emp=new Emp({_id:req.body.keyid,empid:req.body.eid,ename:req.body.ename,sal:req.body.sal})
    emp.save(function(err){
        if(err){
            resp.status(500).send("no data added");
        }
        //it will go to the browser and immediately come back to server
        //with new url  /
        resp.redirect("/")
    });
});

//   /edit/20/aaaa this will display data in the form
router.get("/edit/:empid",function(req,resp){
    Emp.findOne({empid:req.params.empid},function(err,doc){
        if(err){
            resp.status(500).send("no data updated");
        }
        resp.render('update',{title:'Update Emeployee',empob:doc})
    })
})

//update the document retrived with id and modify it in the database
router.post("/update",function(req,resp){
    console.log(req.body);
    Emp.findOne({empid:req.body.empid},function(err,doc){
        if(err){
            resp.status(500).send("no data updated");
        }
        else{
            console.log("in else")
            doc.empid=req.body.empid;
            doc.ename=req.body.ename;
            doc.sal=req.body.sal;
            doc.save(function(err){
                if(err){
                    console.log(err);
                    resp.status(500).send("no data updated");
                }
                //it will go to the browser and immediately come back to server
                //with new url  /
                resp.redirect("/")
            })
        }
       
    })
});

//delete the document with given id and go back to the table
http://localhost:3000/delete/12
router.get("/delete/:empid",function(req,resp){
    Emp.remove({empid:req.params.empid},function(err,doc){
        if(err){
            resp.status(500).send("no data deleted");
        }
        //it will go to the browser and immediately come back to server
        //with new url  /
        resp.redirect("/")
    });
});

module.exports=router;


