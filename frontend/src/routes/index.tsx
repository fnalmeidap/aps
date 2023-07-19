import { Route, Routes, Navigate } from "react-router-dom";
import Login from '../pages/Login';
import TelaEquipe from '../pages/TelaEquipe';
import TelaEvento from '../pages/TelaEventos';

const Null = () => null

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Null />} />
      <Route path="/telaEquipe" element={<TelaEquipe />} />
      <Route path="/telaEvento" element={<TelaEvento />} />
      <Route path="*" element={<Navigate to="/login" replace />} />
    </Routes>
  );
};

export default AppRoutes;
