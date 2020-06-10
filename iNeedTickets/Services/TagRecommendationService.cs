using iNeedTickets.Models;
using iNeedTickets.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iNeedTickets.Services
{
    public class TagRecommendationService : ITagRecommendationService
    {
        private IEventRepository _eventRepository;

        public TagRecommendationService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetRecommendedEvents(string userId, int size)
        {
            var userEvents = _eventRepository.GetEventsByUser(userId);

            var tagsCount = new Dictionary<string, int>();

            foreach(var e in userEvents)
            {
                if (e.Tags != null)
                {
                    var tagsList = e.Tags.Split(" ").ToList();

                    foreach (var t in tagsList)
                    {
                        if (tagsCount.ContainsKey(t))
                        {
                            tagsCount[t]++;
                        }
                        else
                        {
                            tagsCount.Add(t, 1);
                        }
                    }
                }
            }

            var events = _eventRepository.GetAllUpcomingEvents();

            var eventScore = new Dictionary<Event, int>();

            foreach (var e in events)
            {
                if (e.Tags != null)
                {
                    var tagsList = e.Tags.Split(" ").ToList();

                    eventScore.Add(e, 0);

                    foreach (var t in tagsList)
                    {
                        if (tagsCount.ContainsKey(t))
                        {
                            eventScore[e] += tagsCount[t];
                        }
                    }
                }
            }

            return eventScore.ToList().OrderByDescending(e => e.Value).Select(e => e.Key).ToList().Take(size);
        }
    }
}
