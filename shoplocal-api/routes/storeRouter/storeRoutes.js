const express = require('express');
const router = express.Router();
const {firestoreDB,fbAdmin} = require('../../firebaseService');


router.get("/:storeId", (req, res) => {
  let { storeId } = req.params;
  firestoreDB
    .collection(process.env.SHOP_COLLECTION)
    .doc(storeId)
    .get()
    .then((rec) => {
      let data = rec.data();
      if (data !== undefined) {
        res.status(200).json({ data });
      } else {
        res.status(404).statusMessage("not found");
      }
    });
});

router.get("/:storeId/getItems", (req, res) => {
  let { storeId } = req.params;
  firestoreDB
    .collection(process.env.ITEM_COLLECTION)
    .where("storeId", "==", storeId)
    .get()
    .then((resSnapshot) => {
      if (resSnapshot.empty) {
        res.status(200).json({ data: [] });
      } 
      else {
        let items = []
        resSnapshot.forEach(doc=>{
          items.push(doc.data())
        })
        res.status(200).json({ data:items });
      }
    });
});

router.post("/:storeId/addItem", (req, res) => {
  let { description, name, price, quantity } = req.body;
  let { storeId } = req.params;
  firestoreDB
    .collection(process.env.ITEM_COLLECTION)
    .add({ description, name, price, quantity, storeId })
    .then((docRef) => {
      firestoreDB
        .collection(process.env.SHOP_COLLECTION)
        .doc(storeId)
        .update({ items: fbAdmin.firestore.FieldValue.arrayUnion(docRef.id) })
        .then((val) => {
          res.status(200).send(val);
        })
        .catch(err=>{
          res.status(404).json({message:"unsuccessful"})
        })
      ;
    });
});

/* 
router.post("/:storeId/addItems", (req,res)=>{
  let batch = firestoreDB.batch();
  firestoreDB.collection(process.env.ITEM_COLLECTION)

});
*/

router.put("/:storeId/:itemId/update",(req,res)=>{
  let {update} = req.body;
  let{storeId,itemId} = req.params;
  let itemRef = firestoreDB.collection(process.env.ITEM_COLLECTION).doc(itemId);

  itemRef.get().then(doc=>{
    if(doc.exists){

      if(doc.data().storeId !== storeId){
        res.status(401).json({message:"Unauthorized"});
      }
      else{
        itemRef.update(update).then((writeResult) => {
          res.status(200).json({ message: "success", result: writeResult });
        });
      }
    }
    else{
      res.status(404).json({message:"document does not exist"})
    }
    
  })
    
});

router.delete("/:storeId/:itemId/delete",(req,res)=>{
  let {storeId, itemId} = req.params;
  let itemRef = firestoreDB.collection(process.env.ITEM_COLLECTION).doc(itemId);

  itemRef.get().then(doc=>{

    if(doc.exists){

      let condition = doc.data() && doc.data().storeId
      if(condition && doc.data().storeId !== storeId){
        res.status(401).json({message:"Unauthorized"});
      }
      else{
  
        itemRef.delete().then(onComplete=>{
          firestoreDB
            .collection(process.env.SHOP_COLLECTION)
            .doc(storeId)
            .update({items: fbAdmin.firestore.FieldValue.arrayRemove(itemId)})
            .then(onFinish=>{
              res.status(200).json({message:"success"});
            })
            .catch(err=>{
              res.status(404).json({message:"unsuccessful"});
            })
          ;
        })
  
      }

    }
    else{
      res.status(404).json({message:"document does not exist"})
    }

  })

});






module.exports = router;