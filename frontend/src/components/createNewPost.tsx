export default function CreateNewPost()
{
    return(
        <div>
            <div className="p-6 rounded-lg shadow-lg border border-gray-100">
                    <h3 className="font-bold text-xl text-padel-primary mb-4 border-b pb-2 ">What's on your mind ?</h3>
                   <textarea id="post-input"className="w-full p-3 border border-gray-300 rounded-lg  focus:border-padel-accent focus:outline-none resize-none"
                             placeholder="Write a new post...">
                    </textarea>
                    <div className="flex justify-end mt-3">
                        <button className="px-6 py-2 bg-padel-accent text-medium text-bold text-white shadow-md border border-padel-accent rounded-md hover:bg-emerald-600 transition duration-200 "> Post Update</button>
                    </div>
                </div>
                <div className="flex border border-gray-200 text-gray-600">
                    <button className="py-2 px-4 border-b-2 border-padel-accent text-padel-accent font-semibold">
                        My Posts
                    </button>
                    {/* Potentially can be more tabs */}
                <div/>
            </div>
        </div>
    );

}