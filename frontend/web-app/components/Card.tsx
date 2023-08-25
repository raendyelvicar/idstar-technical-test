"use client";
import React, { useState } from "react";
import Modal from "./Modal";

type Props = {
  title: string;
  amount: string;
  type: string;
};

export default function Card(props: Props) {
  const { title, amount, type } = props;

  return (
    <div>
      <div className="max-w-sm rounded-md overflow-hidden shadow-lg mx-6">
        <div className="px-12 py-4 text-center cursor-pointer">
          <div className="font-bold text-xl mb-2">{amount}</div>
          <p className="text-gray-700 text-base">{title}</p>
        </div>
      </div>
    </div>
  );
}
