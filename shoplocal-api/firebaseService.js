const fbAdmin = require('firebase-admin');


fbAdmin.initializeApp({
  credential: fbAdmin.credential.applicationDefault(),
  databaseURL: process.env.FIREBASE_DATABASE_URL
})

let firestoreDB = fbAdmin.firestore();


module.exports = {
  firestoreDB,
  fbAdmin
}