// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getFirestore, connectFirestoreEmulator } from "firebase/firestore";

const firebaseConfig = {
  apiKey: "AIzaSyD-jJtuDPMEIxPuU6326nOmHUkboHyaudI",
  authDomain: "printmanager-30145.firebaseapp.com",
  projectId: "printmanager-30145",
  storageBucket: "printmanager-30145.firebasestorage.app",
  messagingSenderId: "931311919649",
  appId: "1:931311919649:web:b925eb98651a0b6a327960",
  measurementId: "G-PPLJ3GYWRZ"
};

const app = initializeApp(firebaseConfig);
export const db = getFirestore(app);