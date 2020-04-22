require('dotenv').config();
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');

const authRouter = require('./routes/authRouter/authRoutes');
const storeRouter = require('./routes/storeRouter/storeRoutes');
const itemRouter = require('./routes/itemRouter/itemRoutes')
//const firebaseAdmin = require('firebase-admin');
const cors = require('cors');

const app = express();

// firebaseAdmin.initializeApp({
//   credential: firebaseAdmin.credential.applicationDefault(),
//   databaseURL: process.env.FIREBASE_DATABASE_URL
// })


const corsOptions = {
  origin:process.env.CORS_ORIGINS
}

app.use(cors(corsOptions));


app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));



app.use('/auth',authRouter);
app.use('/store',storeRouter);
app.use('/item',itemRouter);



module.exports = app;
