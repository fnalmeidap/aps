import axios from "axios";

export const api = axios.create({
  baseURL: "http://localhost:5211",
  headers: {
    Accept: 'application/json'
  }
});
