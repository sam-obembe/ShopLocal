const express = require('express');
const router = express.Router();
const{firestoreDB} = require('../../firebaseService');


router.get("/:itemId",(req,res)=>{
  let {itemId} = req.params;
  let data = {}
  firestoreDB
    .collection(process.env.ITEM_COLLECTION)
    .doc(itemId)
    .get()
    .then((doc) => {
      if(doc.exists === true){
        data.item = doc.data()

        firestoreDB
          .collection(process.env.SHOP_COLLECTION)
          .doc(data.item.storeId)
          .get()
          .then(storeDoc=>{
            if(storeDoc.exists === true){
              data.store = storeDoc.data();
              res.status(200).json(data);
            }
            else{
              res.status(404).json({message:"not found"})
            }
          })
          .catch(err=>{
            res.status(404).json({message:"not found"})
          })
        ; 
      }
      else{
        res.status(404).json({message: "not found"});
      }
    })
    .catch(err=>{
      res.status(500).json({message:"could not complete"})
    })
  ;

});

router.get("/search/:searchString",(req,res)=>{
  let {searchString} = req.params;
  
  firestoreDB
    .collection(process.env.ITEM_COLLECTION)
    .where("name", "in", [searchString])
    .get()
    .then((queryResult) => {

      if (queryResult.empty === true) {
        res.status(404).json({ message: "nothing found" });
      } 
      else {
        let results = [];
        queryResult.forEach((doc) => {
          results.push(doc.data());
        });
        res.status(200).json({ data: results });
      }
      
    })
    .catch((err) =>
      res.status(500).json({ message: "could not complete request" })
    );
})

module.exports = router;