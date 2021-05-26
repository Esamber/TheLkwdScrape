import React, { useState, useEffect } from 'react';
import axios from 'axios';

const ScoopScraper = () => {
    const [results, setResults] = useState([]);

    useEffect(() => {
        const searchScoop = async () => {
            const { data } = await axios.get(`/api/scraper/scrape`);
            setResults(data);
        }
        searchScoop();
    }, []);


    return (
        <div className="container" style={{ marginTop: 60 }}>
            <div className="jumbotron">
                <h1 class="display-4 text-center">The Lakewood Scrape</h1>
                <hr class="my-4 text-center"/>
                <h3 class="lead text-center">Everything you need to see, nothing you don't!</h3>
            </div>

            <div className="row">
                <div className="col-md-12">
                    {results.map(p => <div className="card">
                        <img className="card-img-top" src={p.imageUrl} alt="Card image cap"></img>
                        <div className="card-body">
                            <a href={p.linkUrl} target="_blank">
                                <h5 className="card-title">{p.title}</h5>
                             </a>
                                <p className="card-text">{ p.blurb}</p>
                                <p className="card-text text-info">
                                    <span>{p.commentCount != 0
                                        ? `${p.commentCount} `
                                        : 'No '
                                    }</span>
                                    Comments
                                </p>
                            </div>
                        </div>)}
                </div>
            </div>
        </div>
    )
}

export default ScoopScraper;