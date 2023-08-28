import React from 'react'
import { useContext, useMemo } from "react";
import { useCallback } from "react";
import { createContext, useState } from "react";
import { useNavigate } from "react-router-dom";

const LoginContext = createContext(null);

export const LoginProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const value = useMemo(
    () => ({
      user,
      setUser,
    }),
    [user]
  );

  return (
    <LoginContext.Provider value={value}>{children}</LoginContext.Provider>
  );
};

export const useLogin = () => {
  const context = useContext(LoginContext);
  if (!context) throw new Error("useLogin must be used within a LoginProvider");
  return context;
};
