export default function HomePage() {
  return (
    <div className="min-h-screen bg-padel-light font-sans p-8">
      <h1 className="text-4xl font-bold text-padel-primary mb-6">
        Tailwind Test Page
      </h1>

      {/* Test text colors */}
      <div className="mb-6">
        <p className="text-padel-primary">This is padel-primary color</p>
        <p className="text-padel-accent">This is padel-accent color</p>
        <p className="text-gray-500">This is gray-500 (built-in Tailwind color)</p>
      </div>

      {/* Test spacing */}
      <div className="mb-6">
        <div className="bg-padel-accent text-white p-4 mb-2">Padding 4</div>
        <div className="bg-padel-primary text-white p-8 mb-2">Padding 8</div>
        <div className="bg-gray-300 text-black m-4">Margin 4</div>
      </div>

      {/* Test flex */}
      <div className="flex gap-4 mb-6">
        <div className="bg-padel-accent text-white p-4 flex-1 text-center">Flex 1</div>
        <div className="bg-padel-primary text-white p-4 flex-1 text-center">Flex 1</div>
        <div className="bg-gray-500 text-white p-4 flex-1 text-center">Flex 1</div>
      </div>

      {/* Test grid */}
      <div className="grid grid-cols-3 gap-4 mb-6">
        <div className="bg-padel-accent text-white p-4">Grid 1</div>
        <div className="bg-padel-primary text-white p-4">Grid 2</div>
        <div className="bg-gray-500 text-white p-4">Grid 3</div>
      </div>

      {/* Test borders */}
      <div className="mb-6">
        <div className="border-4 border-padel-primary p-4 mb-2">
          Border 4 padel-primary
        </div>
        <div className="border-2 border-padel-accent p-4">
          Border 2 padel-accent
        </div>
      </div>

      {/* Test buttons */}
      <div className="mb-6 space-x-4">
        <button className="bg-padel-primary text-white px-6 py-2 rounded hover:bg-padel-accent transition">
          Primary Button
        </button>
        <button className="bg-padel-accent text-white px-6 py-2 rounded hover:bg-padel-primary transition">
          Accent Button
        </button>
      </div>

      {/* Test responsive */}
      <div className="bg-gray-200 p-4 sm:bg-padel-accent md:bg-padel-primary lg:bg-padel-light">
        Resize the screen: small → padel-accent, medium → padel-primary, large → padel-light
      </div>
    </div>
  );
}
