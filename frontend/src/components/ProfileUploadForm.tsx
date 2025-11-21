interface UploadFormProp{
    handleSubmit:(e: React.FormEvent<HTMLFormElement>) => void;
}
export default function UploadForm({ handleSubmit }: UploadFormProp) {
    return(
            <form className="space-y-6" onSubmit={handleSubmit}>
                {/* Personal Details Section  */}
                <div className="grid grid-cols-1 md:grid-cols-2 gap-2">
                    <div>
                        <label htmlFor="name"  className="block text-sm font-medium text-padel-primary mb-1">Full Name</label>
                        <input type="text" autoComplete="off" id="name" name="name" placeholder="Write your name..."
                        className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150"/>
                    </div>
                    <div>
                        <label htmlFor="city" className="block text-sm font-medium text-padel-primary mb-1">City / Location</label>
                        <input type="text" autoComplete="off" id="city" name="city" placeholder="Write your city..."
                            className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150"></input>
                    </div>
                </div>
                <div>
                    <label htmlFor="skill_level" className="block text-sm font-medium text-padel-primary mb-1">Padel Skill Level</label>
                    <select id="skill_level" name="skill_level" defaultValue=""
                        className="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent focus:border-padel-accent transition duration-150 bg-white appearance-none">
                        <option className="text-gray-200" value="" disabled   >Select your level: </option>
                        <option value="1.0">Beginner (1.0)</option>
                        <option value="2.5">Novice (2.5)</option>
                        <option value="3.5" >Intermediate (3.5)</option>
                        <option value="4.5">Advanced (4.5)</option>
                        <option value="5.0">Expert (5.0+)</option>
                    </select>
                </div>
                <div>
                    <label htmlFor="bio" className="block text-sm font-medium text-padel-primary mb-1">Player Bio / Description</label>
                    <textarea id="bio" name="bio" rows={4} placeholder="Tell other players about yourself..."
                        className   ="w-full p-3 border border-gray-300 rounded-lg focus:ring-padel-accent
                        focus:border-padel-accent transition duration-150 resize-none">
                     </textarea>
                </div>
                  <div className="flex justify-end space-x-4 pt-4">
                   
                    <button type="button" 
                        onClick={() => (window.location.href = "/edit/profile")}
                        className="px-6 py-3 text-padel-primary font-semibold border border-padel-primary rounded-lg hover:bg-gray-100 transition duration-200 shadow-md">
                        Cancel
                    </button>
                    <button type="submit" 
                        className="px-6 py-3 bg-padel-accent text-white font-extrabold rounded-lg shadow-xl hover:bg-emerald-600 transition duration-200 transform hover:scale-[1.01]">
                        Save Changes
                    </button>
                </div>
            </form>
    );
}