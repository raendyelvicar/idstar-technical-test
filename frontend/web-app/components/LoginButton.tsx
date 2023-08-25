"use client";

import { signIn } from "next-auth/react";
import React from "react";
const LoginButton = () => {
  return (
    <div>
      {" "}
      <button
        className="hover:cursor-pointer"
        onClick={() => signIn("id-server", { callbackUrl: "/" })}
      >
        Login
      </button>
    </div>
  );
};

export default LoginButton;
