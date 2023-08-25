import LoginButton from "@/components/LoginButton";
import { getCurrentUser } from "./actions/authActions";
import UserActions from "@/components/UserActions";
import Card from "@/components/Card";

export default async function Home() {
  const user = await getCurrentUser();
  return (
    <div>
      <div className="mb-6">
        <div className="nav px-10 py-6 bg-[#f2f5f4] shadow-md">
          <div className="flex flex-row justify-between items-center">
            <ul className="flex flex-row justify-between items-center">
              <li className="mr-8">
                <img src="/circle-logo.webp" width={30} height={30}></img>
              </li>
              <li className="hover:cursor-pointer">Dashboard</li>
            </ul>
            {user ? <UserActions user={user} /> : <LoginButton />}
          </div>
        </div>
      </div>
      <div className="main">
        <div className="text-center mb-8">
          {user ? <h1 className="text-2xl">Transactions</h1> : ""}
        </div>
        <div className="flex flex-col justify-center items-center mb-10 w-full">
          <form className="w-full max-w-lg">
            <div className="flex flex-row -mx-3 mb-6 justify-center items-center">
              <div className="w-full md:w-1/2 px-3 mb-6 md:mb-0">
                <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2">
                  Type
                </label>
                <select
                  className="block appearance-none w-full bg-gray-200 border border-gray-200 text-gray-700 py-3 px-4 pr-8 rounded leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
                  id="grid-state"
                >
                  <option>Deposit</option>
                  <option>Withdraw</option>
                </select>
              </div>
              <div className="w-full md:w-1/2 px-3">
                <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2">
                  Amount
                </label>
                <input
                  className="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
                  id="grid-last-name"
                  type="text"
                  placeholder="0"
                />
              </div>
            </div>
            <button
              className="flex-shrink-0 w-full bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
              type="button"
            >
              Add
            </button>
          </form>
        </div>
        <div className=" flex flex-row justify-center items-center w-full mx-auto mb-6">
          <Card title="Balance" amount="$30,000" type="1"></Card>
          <Card title="Deposit" amount="$50,000" type="2"></Card>
          <Card title="Withdraw" amount="$20,000" type="3"></Card>
        </div>
      </div>
    </div>
  );
}
