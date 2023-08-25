"use client";

import { User } from "next-auth";
import { signOut } from "next-auth/react";
import React from "react";

type Props = {
  user: Partial<User>;
};

const UserActions = ({ user }: Props) => {
  return (
    <div>
      <span className="mr-6">{`Welcome, ${user.email}`}!</span>
      <button
        className="hover:cursor-pointer"
        onClick={() => signOut({ callbackUrl: "/" })}
      >
        Logout{" "}
      </button>
    </div>
  );
};

export default UserActions;
