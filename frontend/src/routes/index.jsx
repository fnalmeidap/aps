import { Route, Routes, Navigate } from "react-router-dom";

const Null = () => null

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/register" element={<Null />} />
      <Route path="/login" element={<Null />} />
      <Route path="/createMusic" element={<Null />} />
      <Route path="*" element={<Navigate to="/login" replace />} />
    </Routes>
  );
};

export default AppRoutes;
