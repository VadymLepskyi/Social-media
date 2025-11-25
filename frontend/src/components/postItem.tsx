export default function PostItem()
{
    return(
        <div>
            <div className="bg-white p-5 rounded-xl shadow-lg border border-gray-100">
                <div className="flex items-center mb-3">
                    <div className="w-8 h-8 bg-gray-200 rounded-full mr-3"></div>
                    <span className="font-semibold text-padel-primary">Jane Doe</span>
                    <span className="text-xs text-gray-400 ml-auto">2 hours ago</span>
                </div>
                    <p className="text-gray-700">
                        Just secured a spot for an open court this Saturday at 10 AM. Looking for 3 players, 3.0-3.5 level. Anyone free? 🎾 #PadelLife #MatchFinder
                    </p>
            </div> 
        </div>
    );
}