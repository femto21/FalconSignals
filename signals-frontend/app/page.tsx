"use client";

import { useEffect, useState } from "react";
import {
  LineChart,
  Line,
  XAxis,
  YAxis,
  Tooltip,
  CartesianGrid,
  ResponsiveContainer,
} from "recharts";

type StockPoint = {
  date: string;
  close: number;
};

export default function Home() {
  const [stockData, setStockData] = useState<StockPoint[]>([]);

  useEffect(() => {
    async function loadData() {
      const res = await fetch("http://localhost:5129/api/v1/stocks/TRT/daily");
      const data = await res.json();

      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const formatted = data.map((item: any) => ({
        date: new Date(item.date).toLocaleDateString(),
        close: item.close,
      }));

      setStockData(formatted.reverse());
    }

    loadData();
  }, []);
  return (
    <main>
      <div className="min-h-screen bg-black text-white px-40 py-10">
        <h1 className="text-4xl font-bold mb-8">FalconSignals</h1>

        <div className="bg-zinc-900 rounded-2xl p-6 shadow-lg">
          <div className="mb-4">
            <h2 className="text-2xl font-semibold">SHOP.TRT</h2>
            <p className="text-zinc-400">Daily Closing Prices</p>
          </div>

          <div className="h-[400px]">
            <ResponsiveContainer width="100%" height="100%">
              <LineChart data={stockData}>
                <CartesianGrid strokeDasharray="3 3" stroke="#333" />

                <XAxis dataKey="date" stroke="#888" />

                <YAxis stroke="#888" domain={["dataMin - 2", "dataMax + 2"]} />

                <Tooltip
                  contentStyle={{
                    backgroundColor: "#18181b",
                    border: "1px solid #333",
                    borderRadius: "12px",
                  }}
                />

                <Line
                  type="monotone"
                  dataKey="close"
                  stroke="#22c55e"
                  strokeWidth={3}
                  dot={false}
                />
              </LineChart>
            </ResponsiveContainer>
          </div>
        </div>
      </div>
    </main>
  );
}
