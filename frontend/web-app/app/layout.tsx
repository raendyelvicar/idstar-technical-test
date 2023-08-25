import "./globals.css";
import type { Metadata } from "next";
import { Lato, Montserrat, Oswald, Poppins } from "next/font/google";

const oswald = Oswald({ weight: "700", subsets: ["latin-ext"] });

export const metadata: Metadata = {
  title: "Transactions App",
  description: "Full Stack App for IDStar",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={oswald.className}>{children}</body>
    </html>
  );
}
