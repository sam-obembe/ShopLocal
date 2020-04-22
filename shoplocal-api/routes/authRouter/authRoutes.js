const express = require('express');
const router = express.Router();
const firebase = require('firebase-admin');
const {firestoreDB} = require('../../firebaseService');


router.post('/signup',(req,res)=>{
  let {email,password,shopName,shopAddress} = req.body;
  
  firebase.auth().createUser({email,password})
  .then(userRecord => {
    firestoreDB.collection(process.env.SHOP_COLLECTION).doc(userRecord.uid).set({
      shopName,
      shopAddress,
      email,
      items:[]
    })
    .then(fin=>{
      res.status(200).send({user:userRecord});
    })
    
  })
  .catch(err=>{
    res.status(501).send({message:"unsuccessful"});
  })
  
})


router.post('/login',(req,res)=>{
  let {email,password} = req.body;
  // firestoreDB.listCollections().then(collections=>{
  //   console.log(collections)
  // })
  //firebase.auth()
})

router.delete('/delete/:id',(req,res)=>{
  let {id} = req.params;
  firebase.auth().deleteUser(id).then(()=>{
    res.status(200).json({message:"successfully deleted"})
  })
  .catch(err=>{
    res.status(501).json({message:"could not delete",error:err})
  })

})

module.exports = router;