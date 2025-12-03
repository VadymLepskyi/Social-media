import {pageProps} from "../interfaces/interfaces"
export default function PageContainer({title,children}:pageProps) {
  return (
    <div className="max-w-4xl mx-auto py-10 px-4 sm:px-6 lg:px-8">
      <h1 className="text-4xl font-extrabold text-padel-primary mb-6">{title}</h1>
      <div className="p-8 rounded-xl shadow-2xl border border-padel-accent/30 space-y-6">
      {children}
      </div>
    </div>
  );
}